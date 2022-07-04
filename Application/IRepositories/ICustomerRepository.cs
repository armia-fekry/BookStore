﻿using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.IRepositories
{
	public interface ICustomerRepository:IBaseRepository<Customer>
	{
	}
}