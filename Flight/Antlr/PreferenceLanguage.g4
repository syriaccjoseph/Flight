grammar PreferenceLanguage;
 
/*
 * Parser Rules
 */
 
preferenceSet       : preference SEPARATOR preference;
preference          : '"' .*? '"' ;

 
/*
 * Lexer Rules
 */
 
SEPARATOR           : 'AND' | 'OR' | 'COMPROMISE' ;
