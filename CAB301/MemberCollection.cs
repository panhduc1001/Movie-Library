//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }




    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        // To be implemented by students in Phase 1
        if (Number == Capacity)
        {
            Console.WriteLine("Cannot add, the collection is full");
            return;
        }
        else
        {
            if (count == 0)
                members[0] = (Member)member;
            else 
            {
                if (Search(member))
                {
                    Console.WriteLine("Cannot add, member with the same name existed");
                    return;
                }
                var result = new Member[count + 1];
                int position = 0;
                while (position < count && member.CompareTo(members[position]) == 1)
                {
                    result[position] = members[position];
                    position++;
                }
                result[position] = (Member)member;
                for (int i = position + 1; i < count + 1; i++)
                    result[i] = members[i-1];
                for (int i = 0; i < count + 1; i++)
                {
                    members[i] = result[i];
                }
                
            }
            Console.WriteLine("Member {0} {1} added successfully", member.FirstName, member.LastName);
            count++;
        }
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {
        // To be implemented by students in Phase 1
        if (Number == 0)
        {
            Console.WriteLine("Cannot delete, the collection is empty");
            return;
        }
        if (!Search(aMember))
        {
            Console.WriteLine("Cannot delete, member not found");
            return;
        }
        else
        {
            
                var result = new Member[count - 1];
                int position = 0;
                while (aMember.CompareTo(members[position]) == 1 && position < count)
                {
                    result[position] = members[position];
                    position++;
                }
                
                for (int i = position + 1; i < count; i++)
                    result[i-1] = members[i];
                for (int i = 0; i < count - 1; i++)
                {
                    members[i] = result[i];
                }
            members[count - 1] = null;
            count--;
            Console.WriteLine("Member {0} {1} deleted successfully", aMember.FirstName, aMember.LastName);
        }
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        if (count == 0)
            return false;
        // To be implemented by students in Phase 1
        int left = 0, right = Number - 1, mid = left + (right - left) / 2;
        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (member.CompareTo(members[mid]) == 0)
                return true;

            if (member.CompareTo(members[mid]) == 1)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        if (member.CompareTo(members[left]) == 0)
            return true;
        else
            return false;
    }

    // Find a given member in this member collection
    // Pre-condition: nil
    // Post-condition: return the reference of the member object in the member collection, if this member is in the member collection; return null otherwise; member collection remains unchanged
    public IMember Find(IMember member)
    {
        if (count == 0)
            return null;
        // To be implemented by students in Phase 1
        int left = 0, right = Number - 1, mid = left + (right - left) / 2;
        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (member.CompareTo(members[mid]) == 0)
                return members[mid];

            if (member.CompareTo(members[mid]) == 1)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        if (member.CompareTo(members[left]) == 0)
            return members[left];
        else
            return null;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }


}

