﻿using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Classes;
using BackupsExtra.Services;

namespace BackupsExtra.Classes
{
    public class HybridTwoAlgorithm : IDeleteAlgorithm
    {
        public List<RestorePoint> DeleteAlgorithm(BackupJob backupJob, int count, DateTime? dateTime)
        {
            List<RestorePoint> trash = backupJob.RestorePoints;
            RestorePoint point = backupJob.RestorePoints.Last();
            var list = trash.Where(restorePoint => restorePoint.Data < point.Data).Take(count).ToList();

            foreach (var restorePoint in list)
            {
                backupJob.RestorePoints.Remove(restorePoint);
            }

            foreach (var restorePoint in backupJob.RestorePoints)
            {
                if (restorePoint.Data < dateTime)
                {
                    backupJob.RestorePoints.Remove(restorePoint);
                }
            }

            if (backupJob.RestorePoints.Count == 0)
            {
                throw new Exception("You can't remove all restorePoints");
            }

            return backupJob.RestorePoints;
        }
    }
}