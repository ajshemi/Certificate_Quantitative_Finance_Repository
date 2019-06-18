'This code is modified version (modified by AKPOJOTOR SHEMI) of codes on page 346,347 of /The complete Guide to Option Pricing Formulas/ by ESPEN GAARDER HAUG,PhD.
'This code was modified(by AKPOJOTOR SHEMI--used Arrays type for select variables) to allow for Standard Deviation Calculations
'see Question_1 worksheet for output

Function Max(X, y)
            Max = Application.Max(X, y)
End Function

'%Monte Carlo Simulation-numeric solution for standard European call and put options
'Today.s stock price, S = 100
'Strike X = 100
'Time to expiry, T  = 1 year
'volatility, v  = 20%
'constant risk-free interest rate, r = 5%=b
Function MonteCarloStandardOption1(CallPutFlag As String, S As Double, X As Double, T As Double, r As Double, b As Double, v As Double, nSimulations As Long) As Double


    ReDim ST(0 To nSimulations)   'ReDim is an array datatype
    ReDim Max_Arg(0 To nSimulations)
    ReDim Sum(0 To nSimulations)
  
    
    Dim Drift As Double, vSqrdt As Double
    Dim payoff_average As Double, Sum_std As Double, Std_Dev As Double
    Dim i As Long, k As Long, z As Integer
    
    Drift = (b - v ^ 2 / 2) * T
    vSqrdt = v * Sqr(T)

'can calculate prices for European call and puts options.' uses If and ElseIf conditional statements
    If CallPutFlag = "c" Then
        z = 1
    ElseIf CallPutFlag = "p" Then
        z = -1
    End If
    
	'initial condition
    ST(0) = S
    Sum(nSimulations) = 0
    Sum_std = 0
    
	'for loop
    For i = 1 To nSimulations
            ST(i) = ST(0) * Exp(Drift + vSqrdt * Application.NormInv(Rnd(), 0, 1)) ' randomly generated independent stock price at expiry
            Sum(nSimulations) = Sum(nSimulations) + Max(z * (ST(i) - X), 0)         'use maximum argument to compare generated stock price at expiry versus strike, sum up results of argument
            Max_Arg(i) = Exp(-r * T) * Max(z * (ST(i) - X), 0)                      'discounted payoff for each maximum argument
            payoff_average = Exp(-r * T) * Sum(nSimulations) / nSimulations         'average discounted payoff
    Next
    
    ' another for loop but for standard deviation calculation
    For k = 1 To nSimulations
          Sum_std = Sum_std + (Max_Arg(k) - payoff_average) ^ 2
          Std_Dev = Sqr(Sum_std / (nSimulations - 1))
    Next k
       
'MonteCarloStandardOption1 = Std_Dev    'use this line to output standard deviation of discounted payoffs
MonteCarloStandardOption1 = payoff_average 'use this line to output average discounted payoff
    
    
End Function

