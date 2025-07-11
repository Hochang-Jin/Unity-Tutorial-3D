using System;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }
    
    private TreeNode root;
    private int[] array = new int[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
 
    private string result = "";

    private void Start()
    {
        foreach (var v in array)
        { 
            root = Insert(root, v);
        }

        Preorder(root);
        Debug.Log($"Preorder: {result}");
        result = "";
        Inorder(root);
        Debug.Log($"Inorder: {result}");
        result = "";
        Postorder(root);
        Debug.Log($"Postorder: {result}");
        
    }

    private TreeNode Insert(TreeNode node, int value)
    {
        if(node == null)
            return new TreeNode(value);
        if(node.value > value)
            node.left = Insert(node.left, value);
        else
            node.right = Insert(node.right, value);
        
        return node;
    }

    private void Visit(TreeNode node)
    {
        result += node.value;
        result += ", ";
    }

    private void Preorder(TreeNode node)
    {
        if (node == null) return;
        Visit(node);
        Preorder(node.left);
        Preorder(node.right);
    }
    
    private void Inorder(TreeNode node)
    {
        if (node == null) return;
        Inorder(node.left);
        Visit(node);
        Inorder(node.right);
    }

    private void Postorder(TreeNode node)
    {
        if (node == null) return;
        Postorder(node.left);
        Postorder(node.right);
        Visit(node);
    }
}
