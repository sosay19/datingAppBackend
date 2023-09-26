using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Data; // Import your ApplicationDbContext and Match model

namespace YourNamespace.Repositories
{
    public class MatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return _context.Matches.ToList();
        }

        public Match GetMatchById(int matchId)
        {
            return _context.Matches.FirstOrDefault(match => match.Id == matchId);
        }

        public IEnumerable<Match> GetMatchesForUser(string userId)
        {
            return _context.Matches.Where(match => match.UserAId == userId || match.UserBId == userId).ToList();
        }

        public void CreateMatch(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void UpdateMatch(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            _context.Entry(match).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMatch(int matchId)
        {
            var match = _context.Matches.FirstOrDefault(match => match.Id == matchId);
            if (match != null)
            {
                _context.Matches.Remove(match);
                _context.SaveChanges();
            }
        }
    }
}
