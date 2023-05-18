using System.Collections.Generic;

namespace OrderHandler.UI.Core.Service.File; 

public interface IFileService<T, I> {
	IEnumerable<T> Open(string filePath);
	void Save(string filePath, IEnumerable<T> data, I fileAddInfo);
}