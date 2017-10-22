using System;
using System.Linq;

namespace IntegerList
{
    
        
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
        }

        public IntegerList()
        {
            _internalStorage = new int[4];
        }
        
        public void Add(int item)
        {
            int itemCount = _internalStorage.Count(i => i != 0);
            try
            {
                _internalStorage[itemCount] = item;
                Console.WriteLine("Element: " + item + " Succesfully added!");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array is not long enough. Attempting to migrate data to a larger one.");
                Console.WriteLine("Old array lenght: " + _internalStorage.Length);
                int[] newArray = new int[(_internalStorage.Length) * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    newArray[i] = _internalStorage[i];
                }
                _internalStorage = newArray;
                _internalStorage[itemCount] = item;
                Console.WriteLine("New array lenght: " + _internalStorage.Length + " Elements: ");
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    newArray[i] = _internalStorage[i];
                }
            }
        }

        public bool Remove(int item)
        {
            int position = 0;
            bool found = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    position = i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                RemoveAt(position);
                return true;
            }
            else
            {
                return found;
            }
        }

        public bool RemoveAt(int index)
        {
            try
            {
                for (int i = index+1; i < _internalStorage.Length; i++)
                {
                    _internalStorage[i - 1] = _internalStorage[i];
                }
                _internalStorage[_internalStorage.Length - 1] = 0;
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
                return false;
            }
        }

        public int GetElement(int index)
        {
            try
            {
                return _internalStorage[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count { get; }

        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = 0;
            }
        }
        
        public bool Contains(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}