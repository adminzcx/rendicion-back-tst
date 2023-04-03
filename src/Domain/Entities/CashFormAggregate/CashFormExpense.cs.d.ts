declare module server {
	interface cashFormExpense extends baseEntity {
		number: number;
		date: Date;
		cashForm: {
			period: string;
			presentationDate?: Date;
			user: {
				firstName: string;
				lastName: string;
				email: string;
				cuit: string;
				employeeRecord: string;
				isAdministrator: boolean;
				branchFrom: {
					subZone: {
						zone: {
						};
					};
				};
				position: {
					isBranchRequired: boolean;
					isSubZoneRequired: boolean;
					isZoneRequired: boolean;
					isSectorRequired: boolean;
					isManagementRequired: boolean;
				};
				category: {
				};
				branch: {
					subZone: {
						zone: {
						};
					};
				};
				zone: {
				};
				subZone: {
					zone: {
					};
				};
				sector: {
					management: {
						hasSpecialPermissions: boolean;
					};
					hasSpecialPermissions: boolean;
				};
				management: {
					hasSpecialPermissions: boolean;
				};
				nextLevelAdmin: any;
				firstLevelPosition: any[];
				indirectsPosition: any[];
				paresLevelPosition: any[];
				name: string;
			};
			branch: {
				subZone: {
					zone: {
					};
				};
			};
			organism: {
				isDefault: boolean;
			};
			cashFormNumber: string;
			subTotalCoins?: number;
			subTotalCash?: number;
			totalCash?: number;
			totalExpense?: number;
			creditCardDate?: Date;
			totalCreditCard?: number;
			totalPending?: number;
			totalPendingDate?: Date;
			fundTotal?: number;
			balanceTotal?: number;
			total?: number;
			totalDifference?: number;
			description: string;
			status: {
			};
			previousStatus: {
			};
			isDeleted: boolean;
			cashes: any[];
			expenses: server.cashFormExpense[];
			audits: any[];
			comments: any[];
		};
		user: {
			firstName: string;
			lastName: string;
			email: string;
			cuit: string;
			employeeRecord: string;
			isAdministrator: boolean;
			branchFrom: {
				subZone: {
					zone: {
					};
				};
			};
			position: {
				isBranchRequired: boolean;
				isSubZoneRequired: boolean;
				isZoneRequired: boolean;
				isSectorRequired: boolean;
				isManagementRequired: boolean;
			};
			category: {
			};
			branch: {
				subZone: {
					zone: {
					};
				};
			};
			zone: {
			};
			subZone: {
				zone: {
				};
			};
			sector: {
				management: {
					hasSpecialPermissions: boolean;
				};
				hasSpecialPermissions: boolean;
			};
			management: {
				hasSpecialPermissions: boolean;
			};
			nextLevelAdmin: any;
			firstLevelPosition: any[];
			indirectsPosition: any[];
			paresLevelPosition: any[];
			name: string;
		};
		vendor: string;
		cashConcept: {
			costCenter: {
			};
			calipso: string;
		};
		costCenter: {
		};
		total: number;
		documentAttached: string;
		isDeleted: boolean;
	}
	interface baseEntity {
		id: number;
	}
}
