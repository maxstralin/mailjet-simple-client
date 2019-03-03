using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public enum EmailPriority
    {
        /// <summary>
        /// Low priority queue (FIFO)
        /// </summary>
        LowPriorityFifo = 0,
        /// <summary>
        /// Goes before the low priority queue
        /// </summary>
        LowPriorityLifo = 1,
        /// <summary>
        /// High priority queue (FIFO)
        /// </summary>
        HighPriorityFifo = 2,
        /// <summary>
        ///  Goes before the high priority queue (LIFO)
        /// </summary>
        HighPriorityLifo = 3
    }
}
