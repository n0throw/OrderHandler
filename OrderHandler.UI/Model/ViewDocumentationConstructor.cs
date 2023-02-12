using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model;

internal class ViewDocumentationConstructor : PropertyChanger
{
    private DateOnly plannedDate;
    private string userName;
    private DateOnly date;

    public DateOnly PlannedDate
    {
        get => plannedDate;
        set
        {
            plannedDate = value;
            OnPropertyChanged("PlannedDate");
        }
    }

    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged("UserName");
        }
    }
    public DateOnly Date
    {
        get => date;
        set
        {
            date = value;
            OnPropertyChanged("Date");
        }
    }
}
