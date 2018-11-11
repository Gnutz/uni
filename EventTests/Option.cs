using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTest.Model
{
    public class Option
    {
        public string _OptionText { get; set; }
        public bool _IsRight { get; set; }
        public int _QuestionID { get; set; }
        public int _OptionID { get; set; }

        public Option(string optionText, bool isRight)
        {
            _OptionText = optionText;
            _IsRight = isRight;
        }

    }
}
