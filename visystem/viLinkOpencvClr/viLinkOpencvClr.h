#pragma once

#include <opencv2/opencv.hpp>

using namespace System::Drawing;
using namespace System::Drawing::Imaging;

namespace viLinkOpencvClr {
	public ref class ImageProcessor
	{
		// TODO: 여기에 이 클래스에 대한 메서드를 추가합니다.
	public:
		static Bitmap^ ThresholdImage(Bitmap^ input, double threshValue, 
			int type, bool isOtsu, int% nOtsuValue);
		// C# 연동 시 파라미터 값 반환은 % 기호 적용

	private:
		static cv::Mat BitmapToMat(Bitmap^ bmp);
		static Bitmap^ MatToBitmap(const cv::Mat& mat);
	};
}
