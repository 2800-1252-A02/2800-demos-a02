# ica01 - Early Feedback
| Student Name         | Categorize | Odds | Singles | RandoDic | FirstDup | Qint | Qstr | Misc |
| -------------------- | ---------- | ---- | ------- | -------- | -------- | ---- | ---- | ---- |
| Azam, Qazi           |            |      | D       | SR       | FD E     |      |      | QC   |
| Brown, Nathan        | C          | C I1 | C       | SR BN    | FD2      | I2   |      | QC AE PB|
| Chi Buwag, Brad      | C          |      | CB      | C SR I2  | C  FD    |      |      | QC AE + xtra ica in repo |
| Durand, Noah         | C          | C W  | I2      | EA       | E FD2    | C    | C    | AE   |
| Kola-Ajayi, Ayomikun | C          | W    | I1      | SR EX EA |          | C    | C    |      |
| Kriese, Nathan       | C          | W    | C       | SR KN    |          | C    | C    | array?     |
| Lee, Jeonghoon       | C          | C W  | I1      | SR EA LJ | E        |      |      | QC   |
| Mahato, Kunal        | C          | C W  | I1      | EA       | FD NTS   | C    |      | QC   |
| Mendoza, Kurt        |            |      |         |          |          |      |      |      |
| Neumann, Karl        | NK         |      | NTS     | SR EA    | FD2      |      |      | QC   |
| Omasta, Ryan         | C          | C ?  |         | AE       | NTS      | ?    | ?    |      |
| Pham, Bao            | PB C       | C W  | NTS     | SR AE    | ?        |      | ?    |      |
| Sparrow, Kaden       | C          | SK   | NTS     | EA EX I1 | C E FD2  | ?    | ?    | QC   |

Legend : 
PB - Programmers Block missing or missing required elements
C - constraints missing
D - Duplicate calls - inefficient
SR - NO local Random objects, declare a static for your library class use
AE - ArgumentException - Message wrong format
QC - Some/All Derived CTORs missing - you require 2, as discussed in class
I1 - Inefficient, nested loop with extension method that iterates results in unnecessary nested iteration looping, or other non-optimal choice
I2 - unnecessary ToList() or other temporary collection, already an IEnumerable
E - No use of `default` keyword allowed
EA - `lementAt()`works on dictionary
EX - Exception check wrong or missing
W - `Where()` ? don't reinvent the wheel
NTS - Not To Spec
? - Check it over

FD - As discussed in class. Single pass solution requires that item returned is first dup encountered, not in existance.
FD2 - Dup found, but not returning first instance

BN - Dictionary must allow for different Key/Value types, T,T will only allow dictionaries with same K,V types
CB - Appears to fail if 3 elements in source - tested ?
KN - NTS(Not To Spec) Wrong type returned
LJ - Rand range wrong - tested ?
NK - Odds - Where() ?, temp collection ?, order fail
PB - Must follow the spec. Many function names wrong, move all fncs to single static class/file, no yield use yet, 
SK - Crash with 1 - tested ? Not ordered ? ElementAt() ?

