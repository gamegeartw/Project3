using System;

namespace Project3.Core
{
    public interface ICreate
    {
        DateTime CreatedTime { get; set; }

        string CreatedBy { get; set; }
    }
}