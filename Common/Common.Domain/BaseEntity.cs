﻿namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreateDate { get; }
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }

    }
}
