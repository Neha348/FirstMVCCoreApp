using FirstMVCCoreApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertConfig;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfig)
        {
             _newBookAlertConfig = newBookAlertConfig;
        }

        public string Getname()
        {
            return _newBookAlertConfig.CurrentValue.BookName;
        }
    }
}
