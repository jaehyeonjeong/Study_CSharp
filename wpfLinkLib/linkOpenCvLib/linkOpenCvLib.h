#pragma once

using namespace System;

namespace linkOpenCvLib {
	// OpenCV 라이브러리 추가 후 Mat 클래스 생성
	public ref class CV 
	{
	public:
		static array<Byte>^ LoadGrayImage(System::String^ path, int% width, int% height);
	};
}
