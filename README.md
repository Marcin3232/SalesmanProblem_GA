# SalesmanProblem_GA
A student project realize a visualization of the traveling salesman problem with the use of genetic algoritm.

# Application example

![](https://github.com/Marcin3232/SalesmanProblem_GA/blob/master/BionikaAPP2/image/example1.png)
![](https://github.com/Marcin3232/SalesmanProblem_GA/blob/master/BionikaAPP2/image/example2.png)
# Introducing
## project assumptions
The aim of the project is to solve the traveling salesman problem with the use evolution algorithms. In this project, we used a genetic algorithm. Visualization of the problem, added possibilities a changes a parametrs. Comparison of the genetic algorithm with the traditional symetric algorithm of the traveling salesman problem.

## Technologies
- .NET core 3.1
- C#
- WPF

# Theory
 **Evolutionary algorithm** - it is an algorithm inspired by biological activities. Algorithm used to patterns of operation modeled on the theory of natural selection and evolution. Evolutionary algorithms are mainly used for optimization problems. With the help of this algorithm, our solution changes over time, more and more adapting to the given recommendations, thanks to which our solution evolves and becomes better and better.

### Genetic Algorithm
**Genetic algorithm** - is a family of algorithms looking for the best solution to a problem based on the phenomenon of genetic evolution. The image of a given problem is also built on the bases of biology. 

### Problems 
The problem itself is the environment in which the population of individuals lives, where each of them has its own genotype - a set of information that is the basis for the formation of a phenotype - a set of features of a given individual, which is subject to the assessment of the fitness function. The genotype describes the solution to a problem, and the fitness function evaluates how good the solution it describes.
### Basic definitions- biological
- **Invidual** - single independent unit
- **Population** - it consists of organisms (individuals) which are crossed with each other and can be divided into local populations. Ecological and reproductive interactions between individuals in a given population are more frequent than interactions with individuals from other populations of the same species.
- **Gene** - the basic unit of heredity that determines certain characteristics of the organism.
- **Chromosome** - form of organization of genetic material inside a cell.
- **Mutation** - sudden, unexpected change in genetic material.
- **Crossover** - randomly splitting two chromosomes at a given point and changing them with each other.

### Definition on genetic algorithm
- **Invidual** - a point in the solution space.
- **Population** - a set of points containing a solution.
- **Gene** - represents a bit.
- **Chromosome** - ordered string bit (ordered gene).
- **Mutation** - negation of bits;
- **Crossover** - exchange of bit strings between chromosomes.
- **Adaptation function** - Function returning a number, which is an assessment of the quality of an individual's fitness.

### Coding of individuals
Coding all possible solutions in binary. The length of the coding strings is set at the beginning. Genes are real values(they are binary in normal encoding). Coding examples:
- **Binary coding** - the encoding is in the form of zeros and ones. The positions of the sequence correspond to the powers of two. An example sequence is [1110101001] and corresponds to a decimal number.
- **Logarithmic coding** - used to reduce the length of a binary string.
- **Floating-point encoding** - chromosome strings of different length. Structures richer than strings, e.g. matrices.
- **Real encoding** 

### Initiation
This step creates a base population. It is usually created randomly. The population is assessed, the value of the fitness function of each individual is calculated. As part of optimization, both its minimum and maximum can be searched.

### Mutations
This is a spontaneous random change in genotype. The genetic algorithm simulates the occurrence of mutations. Simulations of its occurrence depend on the constructed algorithm. The mutation rate should not be too high in order to minimize the randomness of the result. The mutation allows some degree of differentiation to be introduced into the gene pool processed by the algorithm.

### Crossover
Crossing along with a mutation are so-called genetic operators. They are used to create a descendant population from the previous one. They are designed to pass genetic information between generations. Chromosomes are randomly matched in pairs. Each pair undergoes interbreeding to form daughter chromosomes. The process flow is to select a random crossing point, then to exchange the relevant parts of the string between the parents.

### Selection
The selection process consists in choosing the best adapted individuals to be included in the invidual group and their genotype will survive to the next generation, i.e. to the next iteration of the algorithm. Selection methods:
- **Roulette wheel method** - each individual receives an area value that is directly proportional to its quality. We start the algorithm that will stop at some individual who will enter the inviduals group. The larger the area for a given individual, the greater the chances of drawing.
- **Tournament selection** - the population is divided into any number of groups, and then the individual with the best adaptation is selected from each of them. It works better than the roulette method.
- **Ranking selection** - individuals are assigned a rank (it depends on the adaptation of a given individual), It consists in selecting individuals in accordance with the assigned ranks. Using such a ranking list, a function (e.g. linear) is defined which determines the number of selected copies of chromosomes depending on their rank. Based on this function, a selection algorithm is implemented.

### Conditions of detention
Conditions under which the algorithm is to stop, in order to limit the time and speed up the program, examples of stopping conditions:
- reaching a certain number of iterations.
- reaching the assumed value of average adaptation.
- no change in improvement between previous generations.
- the disappearance of population diversity in subsequent iterations of the algorithm.

### The traveling salesman problem
It is an optimization problem that consists in finding the shortest path between certain points. An example would be a merchant who must visit each city at least once and return to the starting point. the main goal is to visit these cities in the shortest possible time. The difficulty of the traveling salesman problem is that with a very large amount of data, e.g. cities. The analysis of this data grows tremendously, and so does the computing power.


# Setup

# Inspiration 
The algorithm was based on an existing design: http://www.theprojectspot.com/tutorial-post/applying-a-genetic-algorithm-to-the-travelling-salesman-problem/5 made in Java. We introduced a small changes on algorithm, to convert it to C# code. We added new functionalities. We mainly focused to a visualization a problem, for example we have added a path to a map, showing the best tour (which cities should be visited in a generation). Added possibility to observe how the algorithm is doing by changing its parametrs.

# Autors
Marcin Opiołka(https://github.com/Marcin3232), Tomasz Cieśliński (https://github.com/tomacie861)
