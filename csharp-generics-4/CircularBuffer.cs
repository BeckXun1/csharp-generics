using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{        
    public class CircularBuffer<T>  : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {
                // 当队列超过体积推出第一个压入的队列
                var discard = _queue.Dequeue();
                //利用事件委托监听处理
                OnItemDiscarded(discard, value);
            }
        }

        private void OnItemDiscarded(T discard, T value)
        {
            if (ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscarded(this, args);
            }
        }
        //事件句柄
        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        public bool IsFull { get { return _queue.Count == _capacity; } }

    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discard, T newitem)
        {
            ItemDiscarded = discard;
            NewItem = newitem;
        }

        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }
    }
}
