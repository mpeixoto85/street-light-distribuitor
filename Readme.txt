Evaluate the comprehension of complex problems and deliver of optimal solution.

What we want to evaluate and find in this code test is the following (all considered as must have):
- Deep understanding of the problem
- Use of the most appropriate containers for best efficiency on time and memory
- Write a Readable code
- Write testable or tested code.

Description

We have a neighbourhood that wants to efficiently increase the lighting of its yards. To do this, they will use streetlights with 4 arms. These will be placed at the corners of the houses&#39; yards so that each streetlight can illuminate the yards of the 4 neighbouring houses.

In the neighbourhood, there are recreational areas (parks) that can create asymmetries in the distribution of houses. All plots in the neighbourhood are equally sized, and the parks have the same depth as one plot and a width of 2.5 plots. Write a program that distributes the streetlights in the plots according to the following rules:

- There can be no corner without a streetlight, except for the parks.
- There can be no more than one streetlight on adjacent corners.

[
[ "H","H","P","H","H"],
[ "H","H","H","H","H","H","H"],
[ "H","H","H","H","H","H","H"],
[ "H","H","H","H","H","H","H"]
]

The Hs indicate the position of a house, and the Ps indicate a park.
The output format should be the same with the following encoding:
- L for a streetlight on the left corner
- R for a streetlight on the right corner
- B for streetlights on both corners
- N for no streetlight

Every two consecutive rows share their backyards, and have a road separating them from the next rows. If the number of rows is odd the last row of houses will not have houses behind it. The output JSON of the configuration shown in the image:
[
["N","N","N","B","R"],
["B","R","R","R","R","R","R"],
["B","R","R","R","R","R","R"],
["N","N","N","N","N","N","N"]
]

Good Practices:

- Readable and maintainable code
- Design patterns
- SOLID principles
- Dependency Injection
- Testable and tested code