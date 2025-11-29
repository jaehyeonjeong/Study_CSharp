#include "pch.h"
#include "linkOpenCvLib.h"
#include <opencv2/opencv.hpp>
using namespace System;
using namespace System::Runtime::InteropServices;

// C#에서 전달된 이미지 경로를 받아서
// OpenCV로 그레이스케일 이미지를 로드한 뒤
// byte[] 형태로 반환하는 함수
// ^:- C++/CLI의 ^ 는 GC(가비지 컬렉터)가 관리하는 .NET 객체를 가리킴
// % : tracking reference (참조 전달, out 역할)
array<Byte>^ linkOpenCvLib::CV::LoadGrayImage(System::String^ path, int% width, int% height)
{
    //System::String ^ → std::string 변환
    // Marshal::StringToHGlobalAnsi는 .NET 문자열을 ANSI 기반 C 문자열로 변환해줌
    IntPtr ptr = Marshal::StringToHGlobalAnsi(path);
    std::string file = static_cast<char*>(ptr.ToPointer());
    Marshal::FreeHGlobal(ptr);          // 변환에 사용된 메모리 해제

    // OpenCV로 이미지 로드 (그레이 스케일)
    cv::Mat img = cv::imread(file, cv::IMREAD_GRAYSCALE);

    // 이미지 로드 실패 시 null 반환
    if (img.empty())
        return nullptr;

    // 이미지 크기 출력용 (C#에서 ref로 받음)
    width = img.cols;
    height = img.rows;

    // Mat의 전체 바이트 크기 계산
    int size = img.total() * img.elemSize();

    // C#으로 전달할 byte[] 생성
    array<Byte>^ buffer = gcnew array<Byte>(size);

    // OpenCV Mat의 raw 데이터를 C# byte[] 로 복사
    // Marshal::Copy(IntPtr src, array dst, startIndex, size);
    Marshal::Copy(IntPtr(img.data), buffer, 0, size);

    // C#으로 bytep[] 전환
    return buffer;
}

