using System.Collections;
using Newtonsoft.Json;
namespace Program;

public class CustomCollection<T> where T : Advertisement
{
    private readonly SortedSet<string> _keys;
    private List<T> _container;
    public CustomCollection()
        {
            _keys = new SortedSet<string>();
            _container = new List<T>();
        }

    protected IList List { get; }

    public T this[int index] => _container[index];

    public void Add(T item)
        {
            _keys.Add(Convert.ToString(item.ID));
            _container.Add(item);
        }

    public void Clear()
        {
            _keys.Clear();
            _container.Clear();
        }

    public bool Contains(int id) => _keys.Contains(Convert.ToString(id));

    public int? FoundIndex(int id)
        {
            if (!Contains(id))
                return null;

            for (int i = 0; i < _container.Count; ++i)
            {
                if (_container[i].ID == id)
                    return i;
            }
            return null;
        }

    public bool Remove(int id)
        {
            if (Contains(id))
            {
                _keys.Remove(Convert.ToString(id));

                int index = FoundIndex(id) ?? -1;
                _container.RemoveAt(index);

            }

            return false;
        }

    public bool Edit(int id, T newItem)
        {
            if (newItem.ID != id)
                return false;

            int? index = FoundIndex(id);

            if (index != null)
            {
                _container[index.Value] = newItem;
                return true;
            }

            return false;
        }

    public CustomCollection<T> Filter(string? expr = null)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return this;
            }
            CustomCollection<T> filtered = new CustomCollection<T>();

            foreach (T item in _container)
            {
                if (!item.Contains(expr))
                    continue;

                filtered._keys.Add(Convert.ToString(item.ID));
                filtered._container.Add(item);
            }
            return filtered;
        }

    
    public void Sort(string field)
    {
        _container = _container.OrderBy(item => item.GetType().GetProperty(field)?.GetValue(item)).ToList();
    }

    public void ReadJsonFile(string file_name)
    {
        List<T> data = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file_name));

        foreach (T item in data)
        {
                if (item.Errors.Count() == 0)
                    _container.Add(item);
                else
                {
                    foreach (KeyValuePair<string, string> kvp in item.Errors)
                    {
                        Console.WriteLine($"Error msg :{kvp.Value}");
                    }
                }
        }
    }

    public void WriteToFile(string filename)
    {
        var json = JsonConvert.SerializeObject(_container);
        if (File.Exists(filename) == false)
            File.WriteAllText(filename, json);
        else
        {
            File.Delete(filename);
            File.WriteAllText(filename, json);
        }
    }
    public void PrintContainer()
    {
        foreach (T item in _container)
        {
                Console.WriteLine(item);
        }
    }
}