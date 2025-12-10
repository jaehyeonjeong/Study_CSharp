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

	Bitmap^ ImageProcessor::MatToBitmap(const cv::Mat& mat) {
		PixelFormat format = PixelFormat::Format24bppRgb;
		if (mat.type() == CV_8UC1)
			format = PixelFormat::Format8bppIndexed;
		else if (mat.type() == CV_8UC4)
			format = PixelFormat::Format32bppArgb;

		Bitmap^ bmp = gcnew Bitmap(mat.cols, mat.rows, format);

		Rectangle rect(0, 0, bmp->Width, bmp->Height);
		BitmapData^ bmpData = bmp->LockBits(rect,
			ImageLockMode::WriteOnly,
			format);

		cv::Mat matCopy(mat.rows, mat.cols, mat.type(),
			bmpData->Scan0.ToPointer(), bmpData->Stride);

		mat.copyTo(matCopy);

		bmp->UnlockBits(bmpData);

		return bmp;
	}
}
