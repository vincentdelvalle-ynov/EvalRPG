# EvalRPG

## Contexte
Cette libraire pose les bases d'une architecture pour gérer un jeu de rôle. Mais cette librairie n'est pas autonome et n'a pas vocation à l'être. En effet, pour l'utiliser dans un jeu, toute la gestion des règles devra être écrite dans une librairie à part. Cela pour créer tous les personnages, les capacités, mais également les règles de calculs des caractéristiques en fonction des attributs des personnages. Tous ces éléments sont paramétrables.

Pour vous guider, vous pouvez consulter le dossier "Exemples" dans lequel ces classes sont utiliser pour créer un sénorio basique.

## Partie 1 : World
Dans cette première partie, tous les tests unitaires sont déjà écrits, ainsi que les méthodes de toutes les classes. Seul manque le contenu des méthodes (noté avec un //TODO). L'exercice consiste donc à écrire le contenu des méthodes, et de vérifier si tous les tests passent au vert. 

Aucune méthode ne manque! Si vous avez l'envie d'en rajouter pour que votre code fonctionne, méfiez-vous! D'une part, il faudra ajouter des TU pour vos nouvelles méthodes, et d'autre part, aucun méthode supplémentaire n'est nécessaire pour que la librairie fonctionne.

![UML - World](https://github.com/vincentdelvalle-ynov/EvalRPG/blob/master/World%20-%20Class%20Diagram.png)

## Partie 2 : Beings
Pour cette seconde partie, c'est l'inverse. Tout le code de la librairie est écrit, mais pas les tests unitaires. Vous devrais donc rajouter les classes et méthodes de test pour vérifier le bon fonctionnement de cette partie de la librairie.

Il est possible que le code écrit ne fonctionne pas correctement. Cependant, vous ne serai pas pénalisés si les TU restent rouge. Ce qui importe, c'est de tester un maximum de choses et de manière pertinante. En revanche, vous aurez des points supplémentaires pour chaque bug identifié ET corrigé!

![UML - Being](https://github.com/vincentdelvalle-ynov/EvalRPG/blob/master/Beings%20-%20Class%20Diagram.png)
