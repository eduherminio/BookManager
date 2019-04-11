using BookManager.Exceptions;
using BookManager.Logs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Services.Impl
{
    [Log]
    [ExceptionManagement]
    public class BookManagerService : IBookManagerService
    {
    }
}
