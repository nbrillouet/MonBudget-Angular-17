using System;
using System.Collections.Generic;

namespace Budget.MODEL
{
    public class BusinessException : Exception
    {
        public List<BusinessExceptionMessage> BusinessExceptionMessages;

        public BusinessException(List<BusinessExceptionMessage> businessExceptionMessages)
        {
            BusinessExceptionMessages = businessExceptionMessages;
        }
    }

    public class BusinessExceptionMessage
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public bool ForcableSave { get; set; }
        
    }

    public enum EnumBusinessException
    {
        BUS_OPE_ERR_000,     //Opération obligatoire, suppression impossible
        BUS_OPE_ERR_001,     //Opération utilisée dans un ou plusieurs imports
        BUS_OPE_ERR_002,     //Opération utilisée dans un ou plusieurs relevés de compte

        BUS_OTY_ERR_000,     //Type opération obligatoire, suppression impossible
        BUS_OTY_ERR_001,     //Type opération utilisée dans un ou plusieurs import(s)
        BUS_OTY_ERR_002,     //Type opération utilisée dans un ou plusieurs relevé(s) de compte
        BUS_OTY_ERR_003,     //Type opération utilisée dans une ou plusieurs opération(s)

        BUS_OTF_ERR_000,     //Catégorie opération obligatoire, suppression impossible
        BUS_OTF_ERR_001,     //Catégorie opération utilisée dans un ou plusieurs import(s)
        BUS_OTF_ERR_002,     //Catégorie opération utilisée dans un ou plusieurs relevé(s) de compte
        BUS_OTF_ERR_003,     //Catégorie opération utilisée dans une ou plusieurs type d'opération(s)
        BUS_OTF_ERR_004,     //Catégorie opération utilisée dans une ou plusieurs customisation utilisateur

        BUS_ASI_ERR_000,     //Import utilisé dans un ou plusieurs relevé de comptes

        BUS_AUTH_ERR_000,    //Un utilisateur possède déjà cette adresse Email
        BUS_AUTH_ERR_001,    //Le mot de passe doit être supérieur à 8 caractères
        BUS_AUTH_ERR_002,    //Nom utilisateur incorrect
        BUS_AUTH_ERR_003,    //Le mail indiqué n'existe pas
        BUS_AUTH_ERR_004,    //L'utilisateur n'existe pas
        BUS_AUTH_ERR_005,    //L'adresse mail indiqué ne correspond pas à l'adresse mail du compte
        BUS_AUTH_ERR_006,    //Email non vérifié, connexion impossible
        BUS_AUTH_ERR_007,    //Un utilisateur possède déjà ce pseudonyme
        BUS_AUTH_ERR_008,    //Mot de passe incorrect

        BUS_USER_ERR_000,    //Compte non trouvé, validation impossible
        BUS_USER_ERR_001,    //Expiration du délai de validation du compte, validation impossible

        BUS_ACC_ERR_000,      //Ce compte est utilisé par un autre utilisateur
        BUS_ACC_ERR_001,      //Ce numéro de compte existe déjà

        BUS_AS_ERR_001,        //montant obligatoire
        BUS_AS_ERR_002,         //date integration obligatoire
        BUS_AS_ERR_003,          //libellé opération obligatoire
        BUS_AS_ERR_004,         //Opération obligatoire
        BUS_AS_ERR_005,         //méthode opération obligatoire
        BUS_AS_ERR_006,         //Type opération obligatoire
        BUS_AS_ERR_007,         //Catégorie opération obligatoire

        BUS_OD_ERR_001,         //Détail opération obligatoire
        BUS_OD_ERR_002,         //Opération obligatoire
        BUS_OD_ERR_003,         //Mot clef opération obligatoire
        BUS_OD_ERR_004,         //Lieu opération obligatoire
        BUS_OD_ERR_005,         //Mot clef lieu obligatoire
        BUS_OD_ERR_006,         //Libellé recherche opération obligatoire
        BUS_OD_ERR_007,         //Libellé recherche lieu obligatoire
        BUS_OD_ERR_008,         //La paire de mot clef: Operation/Lieu existe déjà pour une autre opération
        BUS_OD_ERR_009,         //Le mot clef opération existe déjà pour une autre opération

        BUS_GMAP_ERR_001,       //Adresse obligatoire

        BUS_REF_OPE_ERR_001,    //Opération obligatoire
        BUS_REF_OPE_ERR_002,    //Libellé opération obligatoire
        BUS_REF_OPE_ERR_003     //Opération déjà existante, ajout impossible
    }
}
