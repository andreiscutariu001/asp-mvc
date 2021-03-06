﻿using System.Collections.Generic;

namespace Wantsome.WebApp01.Models.Employee
{
    public interface IEmployeeManager
    {
        void Save(Employee employee);

        Employee Get(string id);

        IList<Employee> GetAll();
    }
}