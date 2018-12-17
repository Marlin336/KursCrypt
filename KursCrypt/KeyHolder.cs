using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCrypt
{
    public class recieverKey
    {
        public string reciever_address = null;
        public string[] keys = new string[2];
        public recieverKey() { }
        public recieverKey(string address)
        {
            reciever_address = address;
            //keys[0] - private
            //keys[1] - public
        }
    }
    public class holder_elem
    {
        public string user_address = null;
        public List<recieverKey> recievers = new List<recieverKey>();
        public holder_elem() { }
    }

    [Serializable]
    public class KeyHolder
    {
        public List<holder_elem> holder = new List<holder_elem>();
        public KeyHolder() { }
        public void AddUser(string user_address)
        {
            if (!holder.Exists(elem => elem.user_address == user_address))
            {
                holder_elem elem = new holder_elem();
                elem.user_address = user_address;
                holder.Add(elem);
            }
        }
        public void AddReciever(string user, string reciever)
        {
            holder_elem elem = holder.Find(us => us.user_address == user);
            if (!elem.recievers.Exists(el=>el.reciever_address == reciever))
            {
                elem.recievers.Add(new recieverKey(reciever));
            }
        }
        public void SetKey(string user, string reciever, string key, bool isPrivate)
        {
            holder_elem elem = holder.Find(us => us.user_address == user);
            recieverKey rec = elem.recievers.Find(reciv => reciv.reciever_address == reciever);
            if (isPrivate)
            {
                rec.keys[0] = key;
            }
            else
            {
                rec.keys[1] = key;
            }
        }
    }
}
