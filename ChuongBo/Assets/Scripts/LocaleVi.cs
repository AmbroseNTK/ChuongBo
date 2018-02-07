using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LocaleVi : Locale
{
    public override void Init()
    {
        Set(LocaleKey.intro, "Giới thiệu");
        Set(LocaleKey.intro_conv01, "Xin chào các bạn! Tôi là Beach Train, một kỹ sư chuồng bò chuyên nghiệp. Giới thiệu với các bạn, đây là chuồng bò của tôi");
        Set(LocaleKey.intro_conv02, "Đây là nhà của gia đình tôi");
        Set(LocaleKey.intro_conv03, "Đây là một khu đất trống, sau này tôi sẽ dùng nó để làm một số việc");
        Set(LocaleKey.intro_conv04, "Hãy cùng tôi thiết kế một chuồng bò cho thật hay ho nhé!");
    }
}
