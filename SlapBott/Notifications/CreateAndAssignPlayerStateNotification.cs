using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Notifications
{
    public class CreateAndAssignPlayerStateNotification(int charID, int stateID) : INotification
    {
        public int CharID { get; set; } = charID;
        public int StateID { get; set; } = stateID;
    }
}
