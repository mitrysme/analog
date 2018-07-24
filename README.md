# Analog
  Analog est un projet créé dans le but d'analyser rapidement l'état d'une machine lors des opérations de maintenance. Auncun composant n'est installé sur les postes distants. Un processus d'inventaire peut être programmé grâce à une tache planifiée. Les données sont stockées sur une base MySQL.
  Le programme utilise WMI, SNMP, Active directory pour remonter les informations nécessaires. Ce projet est diffusé sous licence GPL. 
  
# Capture
  ![capture](https://dl.dropboxusercontent.com/s/qiuxhnhle8vn3hg/captureAnalogRedim.jpg?dl=0)

# Fonctionalités
  - Informations systeme ( Processeur, numéro de série, version OS, réseau , etc )
  - Ping continu , historique horodaté,statistiques
  - Liste programmes installés 
  - Services
  - Systeme de commentaires, base de connaissance
  - Gestion des process
  - Onglets
  - Inventaire imprimantes ( relevé Active directory + SNMP )
  - inventaire Parc  
  - Exécution commandes à distance (  psexec )
  - Suppression fichiers temporaires multi-profils
  - Sauvegarde infos sur base MySQL
  - Analyse évènements logs système
  - Infos SMART 
  
# Librairies utilisées
  Analog intègre les librairie suivantes, merci aux auteurs respectifs.
  - [CollapsiblePanelBar] (https://www.codeproject.com/Articles/3057/Windows-XP-style-Collapsible-Panel-Bar) ( Derek Lakin )
  - [DataGridViewPercentageColumn]  (http://arsalantamiz.blogspot.fr/2008/04/datagridview-custom-percentage-column.html) ( Arsalan Tamiz )
  - [MDIWindowManager] (https://mdiwinman.codeplex.com/) ( Carlos Moya )
  - [SNMP#NET] (https://sourceforge.net/projects/snmpsharpnet/) ( msinadinovic )


  
