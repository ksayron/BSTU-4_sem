// --- main  
#include <iostream>
#include <stack>
#include "Graph.h"
#include "BFS.h"
#include "DFS.h"


void topologicalSort(int v, bool visited[], std::stack<int>& Stack, graph::AList& g)
{
	
	visited[v] = true;

	
	
	for (int i = 0; i < g.size(v); i++)
		if (!visited[g.get(v, i)])
			topologicalSort(g.get(v, i), visited, Stack, g);

	
	Stack.push(v);
}

int main()
{
	int m[7][7] = {
		//         0  1  2  3  4  5  6
		/*0*/	  {0, 1, 1, 1, 0, 0, 0},
		/*1*/     {0, 0, 0, 0, 0, 0, 0},
		/*2*/	  {0, 0, 0, 0, 0, 0, 0},
		/*3*/	  {0, 1, 0, 0, 0, 1, 1},
		/*4*/	  {0, 1, 0, 0, 0, 0, 0},
		/*5*/	  {0, 0, 1, 0, 0, 0, 0},
		/*6*/	  {0, 0, 0, 0, 1, 1, 0}
	};
	setlocale(LC_ALL, "rus");
	graph::AMatrix g1(7, (int*)m);
	std::cout << std::endl;
	std::cout << std::endl << "-- матрица смежности " << std::endl;
	for (int i = 0; i < g1.n_vertex; i++)
	{
		std::cout << std::endl;
		for (int j = 0; j < g1.n_vertex; j++) std::cout << g1.get(i, j) << " ";
	};
	std::cout << std::endl;

	graph::AList g2(g1);
	std::cout << std::endl;
	std::cout << std::endl << "-- списки смежных вершин  " << std::endl;
	for (int i = 0; i < g1.n_vertex; i++)
	{
		std::cout << std::endl << i << ": ";
		for (int j = 0; j < g2.size(i); j++) std::cout << g2.get(i, j) << " ";
	}
	std::cout << std::endl;

	graph::AMatrix g3(g1);
	std::cout << std::endl;
	std::cout << std::endl << "-- матрица смежности " << std::endl;
	for (int i = 0; i < g3.n_vertex; i++)
	{
		std::cout << std::endl;
		for (int j = 0; j < g3.n_vertex; j++) std::cout << g3.get(i, j) << " ";
	};
	std::cout << std::endl;

	graph::AList g4(7, (int*)m);
	std::cout << std::endl;
	std::cout << std::endl << "-- списки смежных  вершин " << std::endl;
	for (int i = 0; i < g4.n_vertex; i++)
	{
		std::cout << std::endl << i << ": ";
		for (int j = 0; j < g4.size(i); j++) std::cout << g4.get(i, j) << " ";
	}
	std::cout << std::endl;

	BFS b1(g2, 0);
	std::cout << std::endl;
	std::cout << std::endl << "-- поиск в ширину " << std::endl;
	int k1;
	while ((k1 = b1.get()) != BFS::NIL) std::cout << k1 << " ";
	std::cout << std::endl;

	DFS b2(g2);
	std::cout << std::endl;
	for (int i = g2.n_vertex; i < !0; i--) std::cout << b2.get(i) << " ";
	std::cout << std::endl;

	int m3[7][7] = {
		//         0  1  2  3  4  5  6
		/*0*/	  {0, 1, 1, 1, 0, 0, 0},
		/*1*/     {0, 0, 0, 0, 0, 0, 0},
		/*2*/	  {0, 0, 0, 0, 0, 0, 0},
		/*3*/	  {0, 1, 0, 0, 0, 1, 1},
		/*4*/	  {0, 1, 0, 0, 0, 0, 0},
		/*5*/	  {0, 0, 1, 0, 0, 0, 0},
		/*6*/	  {0, 0, 0, 0, 1, 1, 0}
	};
	graph::AList g5(7, (int*)m3);
	DFS b3(g5);
	std::cout << std::endl;
	std::cout << std::endl << "-- поиск в глубину "
		<< std::endl;
	for (int i = 0; i < g5.n_vertex; i++) std::cout << b3.get(i) << " ";
	std::cout << std::endl;

	std::cout << std::endl << "-- топологическая сортировка" << std::endl;
	std::stack<int> Stack;
	
	bool* visited = new bool[g5.n_vertex];
	for (int i = 0; i < g5.n_vertex; i++) visited[i] = false;
	
	for (int i = 0; i < g5.n_vertex; i++)
		if (visited[i] == false)
			topologicalSort(i, visited, Stack, g5);

	while (Stack.empty() == false)
	{
		std::cout << Stack.top() << " ";
		Stack.pop();
	}
	std::cout << std::endl;
	system("pause");
	return 0;
}