using System.Collections.Generic;

namespace CodeCounter.Interfaces
{
   public interface IGetFileLineCountUseCase
   {
       List<FileLineCount> GetLineCountList(string filePath);
   }
}
