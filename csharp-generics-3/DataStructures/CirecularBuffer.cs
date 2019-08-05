using System.Collections;
using System.Collections.Generic;
namespace DataStructures
{
  public interface IBuffer<T>: IEnumerable<T>
  {
    bool IsEmpty{get;}
    void Write(T value);
    T Read();   
  }
  public class Buffer<T>: IBuffer<T>
  {
    // 队列
    protected Queue<T> _queue = new Queue<T>();
    //是否为空允许重写
    public virtual bool IsEmpty
    {
      get{return _queue.Count == 0;}
    }
    // 压入队列
    public virtual void Write(T value)
    {
      _queue.Enqueue(value);
    }
    // 出队列
    public virtual T Read()
    {
      return _queue.Dequeue();
    }
    // 获取迭代对象
    public IEnumerator<T> GetEnumerator()
    {
      foreach(var item in _queue)
      {
        yield return item;
      }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
  public class CircularBuffer<T>: Buffer<T>
  {
    int _capacity;
    public CircularBuffer(int capacity = 10)
    {
      _capacity = capacity;
    }
    public bool IsFull {get{return _queue.Count == _capacity;}}
  }
}