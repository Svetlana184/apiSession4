﻿using System;
using System.Collections.Generic;

namespace apiSession4.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdDepartmentParent { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? IdEmployeeNavigation { get; set; }
}
