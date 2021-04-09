using prjLayoutDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace prjCustomerSysMobile.ViewModel
{
    public class CBindingViewModel:INotifyPropertyChanged
    {
        
        private int position = 0;
        List<CCustomer> list;

        public event PropertyChangedEventHandler PropertyChanged;

        public CBindingViewModel()
        {
            list = (new CCustomerFactory()).getAll();
        }
        public void moveToFirst()
        {
            position = 0;
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs("current"));
        }
        public void moveToPrevious()
        {
            position--;
            if (position < 0)
                position = 0;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("current"));
        }

        internal void moveTo(CCustomer x)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].fId == x.fId)
                {
                    position = i;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("current"));
                    return;
                }
            }
        }

        public void moveToNext()
        {
            position++;

            if (position >= list.Count)
                moveToLast();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("current"));

        }
        public void moveToLast()
        {
            position = list.Count - 1;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("current"));
        }
        public void MoveTo(int to)
        {
            position = to;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("current"));
        }
        public CCustomer current
        {
            get { return list[position]; }
        }

        public List<CCustomer> all
        {
            get { return list; }
        }
    }
}
