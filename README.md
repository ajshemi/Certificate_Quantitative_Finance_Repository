# CQF_repo
cqf projects and exercises

CQF_FINAL_PROJECT.ipynb  #python notebook#
(Pricing a Basket of Credit Default Swaps(CDS))

Commercial Basket CDS products include standardised iTraxx and CDX indices.
These indices typical comprise at least twenty five (25) entities. 
There is lesser need in structuring a customised Basket CDS. 
However, the product(indices) characteristics and pricing methodology give a
practical insight into credit spread pricing and tranches.To this end, we consider pricing a basket CDS of five entities

The main objective of this project to price a basket CDS of five entities using techniques adapted from ISDA procedures
and outlined in project brief documents.
For each reference name, we bootstrap implied survival probabilities from quoted CDS and convert them to a term structure of hazard rates. 
We used historical data of equity returns to estimate default correlation matrices (linear and rank) and 
degree of freedom parameter (i.e., calibrate copula). Matlab’s ksdensity was used to obtain grades, pseudo samples. 
We implemented pricing by Gaussian and t copula separately. Using sampling from copula algorithm,
we repeated the following routine (simulation); generate a vector of correlated uniform random variable, for each reference name, 
we used its term structure (set) of hazard rates (cumulative) to calculate exact default times, 
we then calculated the discounted values of premium and default legs for each instrument from 1st to 5th-to-default. 
We used 100000 X 5 big simulated dataset to conduct Monte Carlo simulation. 
We then average premium and default legs across simulations separately for each kth-to-default instrument. 
Thereafter, we calculated the fair spread as the ratio of default leg to premium leg

MonteCarloStandardOption1.vb    #visual basic application for excel#
(Pricing of European Call and Put Options)

We show how to price/calculation a simple european call and put option (equity derivatives).
This VBA script contains If and ElseIf conditional statements, multiple data types including arrays, random number generation, For-loop statments and excel's Max function. We included standard deviation calculations to quantify error in the monte carlo simulation. Upon request we can share how to price/calculation exotic options.
