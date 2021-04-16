using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    class MyArrayDataExeption: Exception
    {
        public MyArrayDataExeption(int i, int j) 
            : base($"В ячейках {i} {j} обнаружена ошибка")
        {}
    }
}
