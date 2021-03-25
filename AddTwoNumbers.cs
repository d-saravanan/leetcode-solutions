using System;

namespace HRConsoleApp1
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class AddReverseInLinkedList
    {
        public static void Main(string[] args)
        {
            int[] arr1 = new[] { 9 },
                arr2 = new[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 };

            ListNode l1 = new ListNode(arr1[0]), l2 = new ListNode(arr2[0]);
            ListNode current = l1;
            for (int i = 1; i < arr1.Length; i++)
            {
                current.next = new ListNode(arr1[i]);
                current = current.next;
            }
            current = l2;
            for (int i = 1; i < arr2.Length; i++)
            {
                current.next = new ListNode(arr2[i]);
                current = current.next;
            }
            ListNode result = AddTwoNumbers(l1, l2);

            while (result != null)
            {
                Console.Write(result.val + "\t");
                result = result.next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null, head = null;

            int carry = 0;

            bool toContinue = true;

            while (toContinue)
            {
                var sum = ExtractNodeValue(l1) + ExtractNodeValue(l2) + carry;
                carry = 0;
                if (sum > 9)
                {
                    carry = 1;
                    sum -= 10;
                }
                if (head == null)
                {
                    result = head = new ListNode(sum);
                }
                else
                {
                    result.next = new ListNode(sum);
                    result = result.next;
                }
                l1 = l1?.next;
                l2 = l2?.next;
                toContinue = !(l1 == null && l2 == null);
            }

            if (carry > 0)
            {
                result.next = new ListNode(carry);
            }

            return head;
        }

        private static int ExtractNodeValue(ListNode ln)
        {
            return ln == null ? 0 : ln.val;
        }
    }
}
