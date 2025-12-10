using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viWPFOpencv.Enum
{
    enum AdaptiveThreshold
    {
        ADAPTIVE_THRESH_MEAN_C = 0,         // 이웃 픽셀의 평균으로 결정 : 선명하나 잡티가 있음
        ADAPTIVE_THRESH_GAUSSIAN_C = 1      // 가우시안 분포에 따른 가중치의 합으로 결정 : 덜 선명하나 잡티가 적음
    }
}
