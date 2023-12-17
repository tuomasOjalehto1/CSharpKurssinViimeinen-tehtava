Tehtävänä on laskea pankkisiirtojen viitteistä tuttu tarkistenumero ja
tulostaa viitenumero ryhmiteltynä.

Alla on esimerkki laskemisesta. Lasketaan runko-osalle 12345 tarkistenumero:

          runko-osa     1     2     3     4     5
     painokertoimet     3     7     1     3     7
                        -------------------------
              tulot     3    14     3    12    35

näiden tulojen summa on 67

Siis oikealta alkaen kerrotaan numerot vuorollaan painoilla 
7, 3, 1, 7, 3, 1, 7, ... jne

Tarkistenumero on tulojen summa vähennettynä seuraavasta täydestä 
kymmenestä (paitsi jos summa on tasakymmeniä, on tarkiste nolla). 

Esimerkin tapauksessa siis tarkiste on 3. 

Alkuperäinen runko-osa ja tarkiste tulostetaan ruudulle näin: oikeanpuoleisimpaan 
ryhmään neljä + tarkiste, muihin viisi merkkiä ja ekaan niin monta kuin riittää

Ohjelman tulisi toimia seuraavasti:

Anna viitteen runko-osa : 325308000102798049011

Viitenumero : 32 53080 00102 79804 90117


Ohjelma toimii ainoastaan konsolissa
