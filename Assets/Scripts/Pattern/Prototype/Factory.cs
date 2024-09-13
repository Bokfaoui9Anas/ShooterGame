using System.Collections.Generic;

namespace Pattern.Prototype
{
    public class Factory <T> 
    {
    
        public readonly Dictionary<string,T> Objects = new Dictionary<string, T>();
    

        public T this[string key]
        {
            get
            {
                if (Objects.ContainsKey(key))
                    return Objects[key];
                else
                    throw new KeyNotFoundException("Key not found: " + key);
            }
            set
            {
                if (Objects.ContainsKey(key))
                    Objects[key] = value;
                else
                    Objects.Add(key, value);
            }
        }
        
    
    

   
    }
}
