# Smoothsort
It is an algorithm for sorting in situ. A modified version of heapsort, it uses special kinds of heaps, built from leonardo numbers. It has worst and average case performance of *O(logn)* and best case performance of *O(n)*. This algorithm is a work of art, invented by the genius, Edsger Dijkstra.

**Note** My implementation is still a work in progress and doesn't reflect the true implementation of this algorithm as defined in the orignal paper. I havn't achieved the *O(1)* auxiliary storage space yet which requires understanding of bitwise operations.  

### How it works
On a very high level: It creates an implicit heap out of the given sequence. Then it sorts that heap using psuedo-insertion sort.

### Leonardo Heaps
Leonardo heaps are special type of heaps which are created using leonardo numbers. Leonardo heaps are a collection of leonardo trees which have following properties.
1. Size of trees are strictly decreasing.
2. Each tree obeys a max heap property
3. Root of the trees are in descending order from left to right.
