Public Class win32_battery
    Private m_availability As UInt16

    Private m_BatteryStatus As UInt16

    Private m_EstimatedChargeRemaining As UInt16

    Private m_EstimatedRunTime As UInt32

    Private m_status As String

    Public Property availability() As UInt16
        Get
            Return m_availability
        End Get
        Set(ByVal value As UInt16)
            m_availability = value
        End Set
    End Property

    Public Property batteryStatus() As UInt16
        Get
            Return m_BatteryStatus
        End Get
        Set(ByVal value As UInt16)
            m_BatteryStatus = value
        End Set
    End Property

    Public Property EstimatedChargeRemaining() As UInt16
        Get
            Return m_EstimatedChargeRemaining
        End Get
        Set(ByVal value As UInt16)
            m_EstimatedChargeRemaining = value
        End Set
    End Property

    Public Property estimatedRunTime() As UInt32
        Get
            Return m_EstimatedRunTime
        End Get
        Set(ByVal value As UInt32)
            m_EstimatedRunTime = value
        End Set
    End Property

    Public Property status() As String
        Get
            Return m_status
        End Get
        Set(ByVal value As String)
            m_status = value
        End Set
    End Property

    Public Enum AvailabilityValues

        Autre = 1

        Inconnu = 2

        En_cours_de_fonctionnement_Alimentation_maximale = 3

        Avertissement = 4

        En_test = 5

        Non_applicable = 6

        Éteindre = 7

        Hors_connexion = 8

        Hors_service = 9

        Détérioré = 10

        Non_installé = 11

        Erreur_d_installation = 12

        Économie_d_énergie_Inconnu = 13

        Économie_d_énergie_Mode_alimentation_basse = 14

        Économie_d_énergie_En_veille = 15

        Cycle_d_alimentation = 16

        Économie_d_énergie_Avertissement = 17

        Pause = 18

        Non_prêt = 19

        Non_configuré = 20

        Arrêté_doucement = 21

        NULL_ENUM_VALUE = 0
    End Enum

    Public Enum BatteryStatusValues

        Autre = 1

        Inconnu = 2

        Pleine_charge = 3

        Basse = 4

        Critique = 5

        En_charge = 6

        En_charge_bon_niveau = 7

        En_charge_niveau_faible = 8

        En_charge_niveau_critique = 9

        Non_défini = 10

        Charge_partielle = 11

        NULL_ENUM_VALUE = 0
    End Enum
End Class
