#include "pch.h"

#include "viLinkOpencvClr.h"

using namespace System::Drawing;
using namespace System::Drawing::Imaging;

namespace viLinkOpencvClr {

	Bitmap^ ImageProcessor::ThresholdImage(Bitmap^ input, double threshValue, 
		int type, bool isOtsu, int% nOtsuValue) {
		nOtsuValue = 0;
		cv::Mat matInput = BitmapToMat(input);
		cv::Mat matGray, matBinary;

		cv::cvtColor(matInput, matGray, cv::COLOR_BGR2GRAY);
		// 중요 포인트
		// matGray -> 원본에서 Gray로 변환된 이미지
		// matBinary -> 이진화 결과 이미지
		// threshValue -> 임계값
		// 255(maxval) -> 최대 임계값
		// THRESH_BINARY(type_flag) -> Threshold 타입 
		if (isOtsu)
		{
			// 자동 최적화 Threshold 이미지 처리 (명암 분포가 가장 균일함)
			nOtsuValue = cv::threshold(matGray, matBinary, -1, 255, cv::THRESH_BINARY | cv::THRESH_OTSU);
		}
		else
		{
			cv::threshold(matGray, matBinary, threshValue, 255, type);
		}
		return MatToBitmap(matBinary);
	}

	Bitmap^ ImageProcessor::ThresholdImage(Bitmap^ input, int nadtiveType,
		int nThType, int nblockSize, double dC) {
		cv::Mat matInput = BitmapToMat(input);
		cv::Mat matGray, matBinary;

		cv::cvtColor(matInput, matGray, cv::COLOR_BGR2GRAY);

		cv::adaptiveThreshold(matGray, matBinary, 
			255, nadtiveType,
			nThType, nblockSize, dC);

		return MatToBitmap(matBinary);
	}

	Bitmap^ ImageProcessor::BlendImage(Bitmap^ img1, Bitmap^ img2,
		double alpha, double beta, double gamma)
	{
		// Bitmap → Mat 변환
		cv::Mat mat1 = BitmapToMat(img1);
		cv::Mat mat2 = BitmapToMat(img2);
		cv::Mat matBlend;

		// 두 이미지 크기가 다른 경우 resize (필요 시)
		if (mat1.size() != mat2.size())
		{
			// mat2를 mat1 기준으로 리사이징
			cv::resize(mat2, mat2, mat1.size());
		}

		// addWeighted 적용:  result = alpha * mat1 + beta * mat2 + gamma
		cv::addWeighted(mat1, alpha, mat2, beta, gamma, matBlend);

		// Mat → Bitmap 변환
		return MatToBitmap(matBlend);
	}

	Bitmap^ ImageProcessor::BitWiseCalc(Bitmap^ img1, Bitmap^ img2, int type)
	{
		// Bitmap → Mat 변환
		cv::Mat mat1 = BitmapToMat(img1);
		cv::Mat mat2 = BitmapToMat(img2);
		cv::Mat matResult;

		// 두 이미지 크기가 다른 경우 resize (필요 시)
		if (mat1.size() != mat2.size())
		{
			// mat2를 mat1 기준으로 리사이징
			cv::resize(mat2, mat2, mat1.size());
		}

		switch (type)
		{
		case 0:
			cv::bitwise_or(mat1, mat2, matResult);
			break;
		case 1:
			cv::bitwise_and(mat1, mat2, matResult);
			break;
		case 2:
			cv::bitwise_xor(mat1, mat2, matResult);
			break;
		case 3:
			cv::bitwise_not(mat1, matResult);
			break;
		case 4:
			cv::absdiff(mat1, mat2, matResult);
			break;
		}

		return MatToBitmap(matResult);
	}

	Bitmap^ ImageProcessor::GrayColorBitmap(Bitmap^ src)
	{
		// TODO: 여기에 return 문을 삽입합니다.
		cv::Mat srcMat = BitmapToMat(src);		// Bitmap -> cv::Mat 변환
		
		cv::Mat gray;
		cv::cvtColor(srcMat, gray, cv::COLOR_BGR2GRAY);
		
		// Mat → Bitmap 변환
		return MatToBitmap(gray);
	}

	System::Windows::Media::Imaging::BitmapSource^ ImageProcessor::CreateHistogram(System::Drawing::Bitmap^ bitmap)
	{
		// 1. Get Gray(8CU1) Image
		cv::Mat src = BitmapToMat(bitmap);

		int histSize = 256;
		float range[] = { 0, 256 };
		const float* histRange = { range };
		cv::Mat hist;
		cv::calcHist(&src, 1, 0, cv::Mat(), hist, 1, &histSize, &histRange);

		// 2. Normalize and draw curve
		int hist_w = 512, hist_h = 400;
		int bin_w = cvRound((double)hist_w / histSize);

		// Extra bottom margin for ticks/labels
		int bottom_margin = 30;
		cv::Mat histImage(hist_h + bottom_margin, hist_w, CV_8UC3, cv::Scalar(255, 255, 255));

		// Normalize to fit within hist_h (not including margin)
		cv::normalize(hist, hist, 0, hist_h, cv::NORM_MINMAX);

		// Draw histogram curve
		for (int i = 1; i < histSize; i++)
		{
			cv::line(
				histImage,
				cv::Point(bin_w * (i - 1), hist_h - cvRound(hist.at<float>(i - 1))),
				cv::Point(bin_w * i, hist_h - cvRound(hist.at<float>(i))),
				cv::Scalar(0, 0, 0), 2, cv::LINE_AA
			);
		}

		// 3. Draw axis baseline
		cv::line(
			histImage,
			cv::Point(0, hist_h),
			cv::Point(hist_w, hist_h),
			cv::Scalar(0, 0, 0), 1, cv::LINE_AA
		);

		// 4. Draw ticks and labels (inside the image bounds)
		for (int i = 0; i <= 255; i += 50)
		{
			int x = bin_w * i;

			// Tick mark (downwards from baseline)
			cv::line(
				histImage,
				cv::Point(x, hist_h),
				cv::Point(x, hist_h + 6),
				cv::Scalar(0, 0, 0), 1, cv::LINE_AA
			);

			// Label slightly below the baseline, within bottom_margin
			cv::putText(
				histImage,
				std::to_string(i),
				cv::Point(x - 8, hist_h + 22), // adjust for centering
				cv::FONT_HERSHEY_SIMPLEX,
				0.45,
				cv::Scalar(0, 0, 0),
				1,
				cv::LINE_AA
			);
		}

		// 5. Convert to BGRA after all drawing is done
		cv::Mat matRGBA;
		cv::cvtColor(histImage, matRGBA, cv::COLOR_BGR2BGRA);

		return System::Windows::Media::Imaging::BitmapSource::Create(
			matRGBA.cols,
			matRGBA.rows,
			96.0,
			96.0,
			System::Windows::Media::PixelFormats::Bgra32,
			nullptr,
			(System::IntPtr)matRGBA.data,
			matRGBA.step * matRGBA.rows,
			matRGBA.step
		);

	}

	Bitmap^ ImageProcessor::MatToBitmap(const cv::Mat& mat) {
		PixelFormat format;
		Bitmap^ bmp;

		if (mat.type() == CV_8UC1) {
			format = PixelFormat::Format8bppIndexed;
			bmp = gcnew Bitmap(mat.cols, mat.rows, format);

			// 팔레트 설정 (0~255 회색조)
			ColorPalette^ palette = bmp->Palette;
			for (int i = 0; i < 256; i++) {
				palette->Entries[i] = System::Drawing::Color::FromArgb(i, i, i);
			}
			bmp->Palette = palette;
		}
		else if (mat.type() == CV_8UC3) {
			format = PixelFormat::Format24bppRgb;
			bmp = gcnew Bitmap(mat.cols, mat.rows, format);
		}
		else if (mat.type() == CV_8UC4) {
			format = PixelFormat::Format32bppArgb;
			bmp = gcnew Bitmap(mat.cols, mat.rows, format);
		}

		// BitmapData에 Mat 복사
		Rectangle rect(0, 0, bmp->Width, bmp->Height);
		BitmapData^ bmpData = bmp->LockBits(rect, ImageLockMode::WriteOnly, format);

		cv::Mat matCopy(mat.rows, mat.cols, mat.type(),
			bmpData->Scan0.ToPointer(), bmpData->Stride);

		mat.copyTo(matCopy);

		bmp->UnlockBits(bmpData);
		return bmp;

	}

	cv::Mat ImageProcessor::BitmapToMat(Bitmap^ bmp) {
		Rectangle rect(0, 0, bmp->Width, bmp->Height);
		BitmapData^ bmpData = bmp->LockBits(rect,
			ImageLockMode::ReadOnly,
			bmp->PixelFormat);

		int type = CV_8UC3;
		if (bmp->PixelFormat == PixelFormat::Format8bppIndexed)
			type = CV_8UC1;
		else if (bmp->PixelFormat == PixelFormat::Format32bppArgb)
			type = CV_8UC4;

		cv::Mat mat(bmp->Height, bmp->Width, type,
			bmpData->Scan0.ToPointer(), bmpData->Stride);

		bmp->UnlockBits(bmpData);

		return mat.clone();
	}
}
