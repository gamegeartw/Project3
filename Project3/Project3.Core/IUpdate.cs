using System;

namespace Project3.Core
{
    public interface IUpdate
    {
        DateTime? UpdatedTime { get; set; }

        string UpdatedBy { get; set; }
    }
}