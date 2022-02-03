using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace mvctrial2.Services
{
    public class OperationUser
    {
        private readonly ISingletonOperation _singletonOperation;
        public OperationUser(ISingletonOperation singletonOperation)
        {
            this._singletonOperation = singletonOperation;
        }

        public void SayHi()
        {
            MessageBox.Show($"SingletonOperation ({_singletonOperation.GetType()}) says hi!");
        }
    }
}
