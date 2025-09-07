// See https://aka.ms/new-console-template for more information

namespace MyNamespace
{
    public class main
    {
        public static void Main()
        {
            TNode node1 = new TNode(1);
            TNode node2 = new TNode(2);
            TNode node3 = new TNode(3);
            TNode node4 = new TNode(4);
            TNode node5 = new TNode(5);
            TNode node6 = new TNode(6);
            TNode node7 = new TNode(7);


            //node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node2.right = node5;
            //node3.left = node6;
            //node3.right = node7;

            node1.right = node4;
            node1.left = node2;
            node2.right = node3;
            node3.left = node5;
            node3.right = node6;
            //node5.left = node7;

            //BFT(node1);
            ////1,3,2,7,6,5,4
            //MirrorTree1(node1);
            //BFT(node1);

            Console.WriteLine(MaxDiameter(node1));


            //int h = height(node1);
            ////Console.WriteLine(h);
            //int NumNodes = NoNodes(node1);
            //// Console.WriteLine(NumNodes);
            //// 1,2,4,5,3,6,7
            ////preorder(node1);
            ////4,2,5,1,6,3,7
            ////4, 2, 5, 1, 6, 3, 7
            ////inorder(node1);
            //postorder(node1);
            ////4,5,2,6,7,3,1
            //Console.ReadKey();

            //List<string> emails = new List<string>();
            //emails.Add("sahi");
            //emails.Add("sahi");
            //foreach (var item in emails)
            //{
            //    Console.WriteLine(item);
            //}

            //HashSet<string> email = new HashSet<string>();
            //email.Add("sahi");
            //email.Add("sahi");
            //foreach (var item in email)
            //{
            //    Console.WriteLine(item);
            //}

        }


        public static int height(TNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 0;
            return Math.Max(height(root.left), height(root.right)) + 1;
        }


        public static void preorder(TNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.value);
            preorder(root.left);
            preorder(root.right);

        }

        public static void inorder(TNode root)
        {
            if (root == null) return;
            inorder(root.left);
            Console.WriteLine(root.value);
            inorder(root.right);

        }

        public static void postorder(TNode root)
        {
            if (root == null) return;
            postorder(root.left);
            postorder(root.right);
            Console.WriteLine(root.value);
        }

        public static int NoNodes(TNode root)
        {
            int hei = height(root);
            return (int)Math.Pow(2, hei + 1) - 1;
        }

        public static void BFT(TNode root)
        {
            Queue<TNode> BFT = new Queue<TNode>();
            BFT.Enqueue(root);
            while (BFT.Count != 0)
            {
                int length = BFT.Count;
                for (int i = 0; i < length; i++)
                {
                    TNode temp = BFT.Dequeue();
                    Console.Write(temp.value);
                    if (temp.left != null)
                    {
                        BFT.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        BFT.Enqueue(temp.right);
                    }
                }

                Console.WriteLine();
            }
        }

        public static TNode InsertionLevelOrder(TNode root, int val)
        {
            TNode ToBeInsert = new TNode(val);
            if (root == null) return ToBeInsert;
            Queue<TNode> BFT = new Queue<TNode>();
            BFT.Enqueue(root);
            bool IsInsert = false;
            while (BFT.Count != 0 && !IsInsert)
            {
                int length = BFT.Count;
                for (int i = 0; i < length && !IsInsert; i++)
                {
                    TNode temp = BFT.Dequeue();
                    Console.Write(temp.value);
                    if (temp.left == null)
                    {
                        temp.left = ToBeInsert;
                        IsInsert = true;
                        break;
                    }
                    if (temp.right == null)
                    {
                        temp.right = ToBeInsert;
                        IsInsert = true;
                        break;
                    }
                    if (temp.left != null)
                    {
                        BFT.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        BFT.Enqueue(temp.right);
                    }
                }

                Console.WriteLine();
            }
            return root;
        }
        public static void MirrorTree(TNode root)
        {
            if (root == null) return;
            TNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            MirrorTree(root.left);
            MirrorTree(root.right);

        }

        public static TNode MirrorTree1(TNode root)
        {
            if (root == null) return null;
            //if (root.right == null && root.left == null) return root;
            TNode temp = root.left;
            root.left = MirrorTree1(root.right);
            root.right = MirrorTree1(temp);
            return root;


        }

        public static int MaxDiameter(TNode root)
        {
            if (root == null) return 0;
            int val = CalDiameter(root.left) + CalDiameter(root.right) + 1;
            return val;
        }

        public static int CalDiameter(TNode root)
        {
            if (root == null) return 0;
            int Max = Math.Max(MaxDiameter(root.left), MaxDiameter(root.right)) + 1;
            return Max;
        }


        public static int debugdia(TNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 0;
            int D = 0;
            if (root.right != null)
            {
                D += 1;
            }
            if (root.left != null)
            {
                D += 1;
            }
            int LD = debugdia(root.left);
            int RD = debugdia(root.right);

            D += LD + RD;

            Console.WriteLine(root.value + " " + D);

            return D;
        }



}


    public class BinarySearchTree
    {
        TNode root;

        public BinarySearchTree()
        {

        }

        public TNode AddNode(TNode root,int Key)
        {
            if (root == null)
            {
                TNode temp = new TNode(Key);
                return temp;
            }

            if(root.value > Key)
            {
                root.right = AddNode(root.right, Key);
            }
            else
            {
                root.left = AddNode(root.left, Key);
            }
            return root;
        }

        public int inordersuccessor(TNode root)
        {
            TNode IT = root;
            while (IT.left != null)
            {
                IT = IT.left;
            }

            return IT.value;
        }

        public TNode DeleteNode(int Key, TNode root)
        {
            if(root == null)
            {
                return root;
            }
            if(Key > root.value)
            {
                
                root.right = DeleteNode(Key, root.right);
            }
            else if (Key < root.value)
            {
                root.left = DeleteNode(Key, root.left);
            }
            else
            {
                if(root.left == null && root.right == null)
                {
                    root = null;
                    return root;
                }
                else if (root.left == null)
                {
                    root = root.right;
                }
                else if (root.right == null)
                {
                    root = root.left;
                   // return root;
                }
                else 
                {
                    int IOS = inordersuccessor(root.right);
                    root.value = IOS;
                    root.right = DeleteNode(IOS, root.right);
                }
            }

            return root;
        }
    }

    public class TNode
    {
        public int value;
        public TNode left;
        public TNode right;

        public TNode()
        {

        }
        public TNode(int value)
        {
            this.value = value;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}