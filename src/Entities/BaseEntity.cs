﻿namespace DataLayer.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }

        protected BaseEntity()
        {

        }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}