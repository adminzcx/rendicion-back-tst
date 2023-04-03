using System;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Guards
{

    public static class ExpenseFolderGuard
    {
        public static void PathFolderValid(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new ArgumentException("Path inexistente.");
            }

        }
    }
}