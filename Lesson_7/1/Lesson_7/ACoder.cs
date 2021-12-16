using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    public sealed class ACoder : ICoder
    {
        private StringBuilder _myString = new StringBuilder();
        private int _index;

        public string Decode(string decode)
        {
            _myString.Clear();

            foreach (char c in decode)
            {
                _index = (int)(c);

                switch (_index)
                {
                    case 1040:
                        {
                            _index = 1071;
                        }
                        break;
                    case 1072:
                        {
                            _index = 1103;
                        }
                        break;
                    default:
                        {
                            if (1040 <= _index && _index <= 1103)
                                _index -= 1;
                        }
                        break;
                }

                _myString.Append((char)_index);
            }

            return _myString.ToString();
        }

        public string Encode(string encode)
        {
            _myString.Clear();

            foreach (char c in encode)
            {
                _index = (int)(c);

                if (_index == 1105)
                {
                    _index = 1077;
                }

                switch (_index)
                {
                    case 1071:
                        {
                            _index = 1040;
                        }
                        break;
                    case 1103:
                        {
                            _index = 1072;
                        }
                        break;
                    default:
                        {
                            if (1040 <= _index && _index <= 1103)
                                _index += 1;
                        }
                        break;
                }

                _myString.Append((char)_index);
            }

            return _myString.ToString();
        }
    }
}
