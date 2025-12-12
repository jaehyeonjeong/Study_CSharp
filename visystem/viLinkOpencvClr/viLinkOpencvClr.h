#pragma once

#include <opencv2/opencv.hpp>

using namespace System::Drawing;
using namespace System::Drawing::Imaging;

namespace viLinkOpencvClr {
	public ref class ImageProcessor
	{
		// TODO: 여기에 이 클래스에 대한 메서드를 추가합니다.
	public:
		// 1장 Threshold 처리
		// C# 연동 시 파라미터 값 반환은 % 기호 적용
		static Bitmap^ ThresholdImage(Bitmap^ input, double threshValue, 
			int type, bool isOtsu, int% nOtsuValue);		// 일반

		static Bitmap^ ThresholdImage(Bitmap^ input, int nadtiveType,
			int nThType, int nblockSize, double dC);		// 적응형

		// 2장 Calculation
		static Bitmap^ BlendImage(Bitmap^ img1, Bitmap^ img2,
			double alpha, double beta, double gamma);		// 이미지 합성


		static Bitmap^ BitWiseCalc(Bitmap^ img1, Bitmap^ img2, int type);

		// 3장 Histogram
		static Bitmap^ GrayColorBitmap(Bitmap^ src);

		static System::Windows::Media::Imaging::BitmapSource^ CreateHistogram(System::Drawing::Bitmap^ bitmap);

	private:
		static cv::Mat BitmapToMat(Bitmap^ bmp);
		static Bitmap^ MatToBitmap(const cv::Mat& mat);
	};
}
