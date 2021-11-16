using System;
using System.Collections;
using UnityEngine;

public class MyLinkedList<Transform>
{
    public Node<Transform> head;
    public  Node<Transform> Current;
    private int Amount;
        
    public void AddFirst(UnityEngine.Transform obj)
    {
        Node<Transform> toAdd = new Node<Transform>();
        toAdd.data = obj;
        toAdd.next = head;
        head = toAdd;
    }
        
    public void printAllNodes()
    {
        Node<Transform> current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }

    public void AddLast(UnityEngine.Transform obj)
    {
        if (head == null)
        {
            head = new Node<Transform>();

            head.data = obj;
            head.next = null;
        }
        else
        {
            Node<Transform> toAdd = new Node<Transform>();
            toAdd.data = obj;

            Node<Transform> current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = toAdd;
        }
    }

    public void RemoveAt(int index)
    {
        Node<Transform> currentNode = head;

        if (currentNode == null)
        {
            throw new NullReferenceException("Linked List has no head");
        }
            
        if (index == 0)
        {
            head = head.next;
        }

        Node<Transform> prevNode = head;

        while (index > 0)
        {
            prevNode = currentNode;
            currentNode = currentNode.next;
            index--;
                
            if (currentNode == null)
            {
                throw new IndexOutOfRangeException("Index longer than linked list size");
            }
        }

        prevNode.next = currentNode.next;
    }
    
    public void Clear()
    {
        Node<Transform> currentNode = head;

        if (currentNode == null)
        {
            throw new NullReferenceException("Linked List has no head");
        }

        while (currentNode != null )
        {
            Node<Transform> tempNode = currentNode;
            
            currentNode = currentNode.next;
            head = null;

        }
        
    }

    
    public Node<Transform> GetNodeAtIndex(int index)
    {
        Node<Transform> temp = head;

        while (index > 0)
        {
            temp = temp.next;
            index--;
        }

        if (temp == null)
        {
            throw new IndexOutOfRangeException("index to ling");
        }

        return temp;
    }

    public int Count()
    {
        Node<Transform> temp = head;

            if (temp == null)
            {
                return 0;
            }
                
            int size = 1;

            while (temp.next != null)
            {
                temp = temp.next;
                size++;
            }
            return size;
    }



}

public class Node<T>
{
    public Node<T> next;
    public Transform data;

    public Transform Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }
    
    public Node()
    {
        data = Data;
    
    }

    public Node(Transform Data)
    {
        data = Data;
    }

}