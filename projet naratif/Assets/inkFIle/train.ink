~ temp myNumber = 0
-> wagon1
==wagon1==
Vous Arrivez dans le 1er wagon

+ [s'assoir]
-> siege
* {myNumber > 3} [allez dans le 2eme wagon avec la clé]
-> wagon2

==siege==
vous etes assis
->siege.choices
= choices
+ [attendre]
~ myNumber++
-> siege.choices
+ [ce lever]
-> wagon1 
* {myNumber > 3} [prendre la clé sous le siege]
->wagon1
 

==wagon2==
GG
-> END
