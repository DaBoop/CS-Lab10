using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10
{
    class ImgList : ISet<Image>
    {
       
        LinkedList<Image> imgList = new LinkedList<Image>();

        public ImgList() { }
        public ImgList(params Image[] values)
        {
            foreach (Image item in values) 
                Add(item);
        }

        public Image this[int i]
        {
            get
            {
                if (i < 0 || i > imgList.Count)
                    throw new ArgumentException("List index out of bounds");
                else
                {
                    LinkedListNode<Image> node = imgList.First;
                    for (int j = 0; j < i; j++)
                    {
                        node = node.Next;
                    }
                    return node.Value; 
                }
                
            }

            set
            {
                if (i < 0 || i > imgList.Count)
                    throw new ArgumentException("List index out of bounds");
                else
                {
                    LinkedListNode<Image> node = imgList.First;
                    for (int j = 0; j < i; j++)
                    {
                        node = node.Next;
                    }
                    node.Value = value;
                }
            }
        
        }

        public int Count => imgList.Count;

        public bool IsReadOnly => true;

        public bool Add(Image item)
        {
            imgList.AddLast(item);
            if (imgList.Last.Value != null) 
                return true; 
            else 
                return false;
        }

        public void AddFirst(Image item)
        {
            imgList.AddFirst(item);
        }
        public void AddLast(Image item)
        {
            imgList.AddLast(item);
        }

        public void Clear()
        {
            imgList.Clear();
        }

        public bool Contains(Image item)
        {
            return imgList.Contains(item);
        }

        public void CopyTo(Image[] array, int arrayIndex)
        {
            imgList.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<Image> other)
        {
            for (int i = 0; i < imgList.Count; i++)
            {
                foreach (Image item in other)
                {
                    if (this[i] == item)
                        imgList.Remove(this[i]);
                }
            }
            
        }

        public Image Find(Image img)
        {
            return (imgList.Find(img)).Value;
        }

        public IEnumerator<Image> GetEnumerator()
        {
            return imgList.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<Image> other)
        {
            Image[] listCopy = { };
            imgList.CopyTo(listCopy,  0);
            imgList.Clear();
 
            for (int i = 0; i < imgList.Count; i++)
            {
                foreach (Image item in other)
                {
                    if (listCopy[i] == item)
                        imgList.AddLast(listCopy[i]);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Image> other)
        {
            int b;
            if (other.Count() == imgList.Count)
                return false;
            else
            {
                b = 0;
                foreach (Image item in imgList)
                {
                    if (other.Contains(item))
                        b++;
                }

                if (b == imgList.Count) // Если каждый элемент из imgList содержится в other
                    return true;
                else
                    return false;
            }
        }

        public bool IsProperSupersetOf(IEnumerable<Image> other)
        {
            int b;
            if (other.Count() == imgList.Count)
                return false;
            else
            {
                b = 0;
                foreach (Image item in other)
                {
                    if (imgList.Contains(item))
                        b++;
                }

                if (b == other.Count()) // Если каждый элемент из other содержится в imgList 
                    return true;
                else
                    return false;
            }
        }

        public bool IsSubsetOf(IEnumerable<Image> other)
        {
            int b = 0;
            foreach (Image item in imgList)
            {
                if (other.Contains(item))
                    b++;
            }

            if (b == imgList.Count) // Если каждый элемент из imgList содержится в other
                return true;
            else
                return false;
        }

        public bool IsSupersetOf(IEnumerable<Image> other)
        {
            int b = 0;
            foreach (Image item in other)
            {
                if (imgList.Contains(item))
                    b++;
            }

            if (b == other.Count()) // Если каждый элемент из other содержится в imgList 
                return true;
            else
                return false;
        }

        public bool Overlaps(IEnumerable<Image> other)
        {
            foreach (Image item in other)
                if (imgList.Contains(item))
                    return true;
            return false;
        }

        public bool Remove(Image item)
        {
            return imgList.Remove(item);
        }

        public bool SetEquals(IEnumerable<Image> other)
        {
            if (IsSubsetOf(other) && IsSupersetOf(other))
                return true;
            else
                return false;
        }

        public void SymmetricExceptWith(IEnumerable<Image> other)
        { // XOR
            Image[] listCopy = { };
            imgList.CopyTo(listCopy, 0);
            imgList.Clear();

            foreach (Image item in listCopy)
                if (!other.Contains(item))
                    imgList.AddLast(item);
            foreach (Image item in other)
                if (!listCopy.Contains(item))
                    imgList.AddLast(item);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void UnionWith(IEnumerable<Image> other)
        {
            foreach (Image item in other)
                imgList.AddLast(item);
        }

        void ICollection<Image>.Add(Image item)
        {
            imgList.AddLast(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return imgList.GetEnumerator();
        }
    }
}
