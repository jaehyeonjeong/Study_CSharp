using System;
using System.Collections.Generic;
using System.Linq;

namespace viWPFOpencv.Enum
{
    enum Threshold
    {
        THRESH_BINARY = 0,          // 픽셀 값이 임계값을 넘으면 maxValue(255)로 지정
        THRESH_BINARY_INV = 1,      // 0번의 반전
        THRESH_TRUNC = 2,           // 픽셀 값이 임계값을 넘으면 maxValue로 지정 그렇지 않으면 기존 값 유지
        THRESH_TOZERO = 3,          // 픽셀 값이 임계값을 넘으면 원래값을 유지, 넘지 못하면 0으로 지정
        THRESH_TOZERO_INV = 4       // 3번의 반전
    }
}